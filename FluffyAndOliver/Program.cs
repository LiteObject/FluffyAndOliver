namespace FluffyAndOliver
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    using FluffyAndOliver.Data;

    /// <summary>
    /// The program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        public static void Main(string[] args)
        {
            var watch = new Stopwatch();
            watch.Start();

            using (var context = new OrderContext(true))
            {
                /* context.Orders.AddRange(SeedData.GetOrders());
                context.SaveChanges(); */

                var orders = context.Orders;
                Console.WriteLine($"Order Count: {orders.Count()}");
            }

            watch.Stop();
            Console.WriteLine($"Press any key to exit. Elapsed: {watch.Elapsed}");
            Console.Read();
        }
    }
}
