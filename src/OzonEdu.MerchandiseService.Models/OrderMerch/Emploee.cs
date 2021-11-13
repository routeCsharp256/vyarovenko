namespace OzonEdu.MerchandiseService.Models
{
    public sealed class Employee
    {
        /// <summary>
        /// Email
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Размер одежды:
        /// XS, S , M , L , XL , XXL
        /// </summary>
        public string? Size { get; set; }
    }
}
