using MyLeasing.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckPropertyTypesAsync();
            await CheckOwnersAsync();
            await CheckLesseesAsync();
            await CheckPropertiesAsync();
        }

        private async Task CheckPropertiesAsync()
        {
            var owner = _context.Owners.FirstOrDefault();            
            var propertyType = _context.PropertyTypes.FirstOrDefault();
            if (!_context.Properties.Any())
            {
                AddProperty("Calle 43 #23 32", "Pablado", owner, propertyType, 800000M, 2, 72, 4);
                AddProperty("Calle 12 Sur #2 34", "Envigado", owner, propertyType, 950000M, 3, 81, 3);
                await _context.SaveChangesAsync();
            }
        }

        private void AddProperty(
            string address,
            string neighborhood,
            Owner owner,
            PropertyType propertyType,
            decimal price,
            int rooms,
            int squareMeters,
            int stratum)
        {
            _context.Properties.Add(new Property
            {
                Address = address,
                HasParkingLot = true,
                IsAvailable = true,
                Neighborhood = neighborhood,
                Owner = owner,
                Price = price,
                PropertyType = propertyType,
                Rooms = rooms,
                SquareMeters = squareMeters,
                Stratum = stratum
            });
        }

        private async Task CheckLesseesAsync()
        {
            if (!_context.Lessees.Any())
            {
                AddLessee("40215216148", "Ramon", "Martinez", "8091561215", "8495235958", "Calle Sol 1");
                AddLessee("00112319186", "Maria", "Zalabala", "8091561565", "8492335958", "Calle Luna");
                AddLessee("00112414135", "Juan", "Mendoza", "8091561295", "8495289958", "Calle Hector");
                AddLessee("40215975483", "Jose", "Almonte", "8091561236", "8495275958", "Calle Primera");

                await _context.SaveChangesAsync();
            }
        }

        private void AddLessee(
            string document, 
            string firstName, 
            string lastName, 
            string fixePhone, 
            string cellPhone, 
            string address)
        {
            _context.Lessees.Add(new Lessee
            {
                Document = document,
                FirstName = firstName,
                LastName = lastName,
                FixedPhone = fixePhone,
                CellPhone = cellPhone,
                Address = address
            });
        }

        private async Task CheckOwnersAsync()
        {
            if (!_context.Owners.Any())
            {
                AddOwner("40258916148", "Alberto", "Gonzalez", "8091566677", "8495238888", "Calle Mayor");
                AddOwner("00184213516", "Ana", "Ramirez", "8491569813", "8492338658", "Calle Doctor Juan");
                AddOwner("00112159876", "Miguel", "Medina", "8099871295", "8495281234", "Calle 18");
                AddOwner("40215392483", "Josefa", "Alvares", "8091559236", "8295275958", "Calle Luz");
                await _context.SaveChangesAsync();
            }
        }

        private void AddOwner(
            string document, 
            string firstName, 
            string lastName, 
            string fixePhone, 
            string cellPhone, 
            string address)
        {
            _context.Owners.Add(new Owner
            {
                Document = document,
                FisrtName = firstName,
                LastName = lastName,
                FixedPhone = fixePhone,
                CellPhone = cellPhone,
                Address = address
            });
        }

        private async Task CheckPropertyTypesAsync()
        {
            if (!_context.PropertyTypes.Any())
            {
                _context.PropertyTypes.Add(new Entities.PropertyType { Name = "Apartamento"});
                _context.PropertyTypes.Add(new Entities.PropertyType { Name = "Casa" });
                _context.PropertyTypes.Add(new Entities.PropertyType { Name = "Terreno" });
                _context.PropertyTypes.Add(new Entities.PropertyType { Name = "Nave" });
                _context.PropertyTypes.Add(new Entities.PropertyType { Name = "Fabrica" });
                _context.PropertyTypes.Add(new Entities.PropertyType { Name = "Data Center" });
                _context.PropertyTypes.Add(new Entities.PropertyType { Name = "Edificio" });
                await _context.SaveChangesAsync();
            }
        }
    }
}
