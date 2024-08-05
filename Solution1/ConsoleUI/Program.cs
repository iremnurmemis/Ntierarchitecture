using Business;
using DataAccess;
using System;
namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("HELLo");
            //ProductManager productManager1 = new ProductManager(new EfProductDal());
            //var result = productManager1.GetProductDetails();
            //if(result.Success==true) 
            //{
            //    foreach (var product in result.Data)
            //    {
            //        Console.WriteLine(product.ProductName + "/" + product.CategoryName);
            //    }
            //}

            //else 
            //{
            //    Console.WriteLine(result.Message);
            //}
            

         

        //    Console.WriteLine("Categoryler");
        //    CategoryManager categorymanager = new CategoryManager(new EfCategoryDal());
        //    foreach (var category in categorymanager.GetAll())
        //    {
        //        Console.WriteLine(category.CategoryName);
        //    }
        }
    }
}