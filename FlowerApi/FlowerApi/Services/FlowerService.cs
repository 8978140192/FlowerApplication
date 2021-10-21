using FlowerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerApi.Services
{
    public class FlowerService
    {
        private readonly FlowerContext _context;
       

        
        public FlowerService(FlowerContext context)
        {
            _context = context;
          
        }
        public IEnumerable<Flower> FetchFlowerDetails()
        {
            try
            {
                IList<Flower> flowers = _context.Flowers.ToList();
                if (flowers.Count>0)
                {
                    return flowers;
                }

            }
            catch (Exception)
            {

                return null;
            }
            return null;
        }
        public Flower InserNewFlower(Flower newFlower)
        {
            //var flowerNew = _context.Flowers.SingleOrDefault(u => u.name == newFlower.name);
            var flowerNew = _context.Flowers.Count(u => u.name == newFlower.name);
            if (flowerNew!=0)
            {
                return null;
            }

            Flower flower = new();
            flower.name = newFlower.name;
            flower.price = newFlower.price;
            flower.qty = newFlower.qty;
            flower.discription = newFlower.discription;
            try
            {
                _context.Flowers.Add(flower);
                _context.SaveChanges();
                return flower;
            }
            catch (Exception)
            {

                return null;
            }
            

        }
    }
}
