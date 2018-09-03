namespace FluffyAndOliver.Domain.Models
{
    using FluffyAndOliver.Domain.Contracts;

    /// <summary>
    /// The discount.
    /// </summary>
    public class CouponDiscount : IDiscount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CouponDiscount"/> class.
        /// </summary>
        /// <param name="couponCode">
        /// The coupon code.
        /// </param>
        /// <param name="discountRate">
        /// The discount Rate.
        /// </param>
        public CouponDiscount(string couponCode, decimal discountRate)
        {
            this.CouponCode = couponCode;
            this.DiscountRate = discountRate;
        }

        /// <summary>
        /// Gets or sets the coupon code.
        /// </summary>
        public string CouponCode { get; set; }

        /// <summary>
        /// Gets or sets the discount rate.
        /// </summary>
        public decimal DiscountRate { get; set; }

        /// <inheritdoc />
        public decimal Calculate(decimal total)
        {
            return total * this.DiscountRate;
        }
    }
}
