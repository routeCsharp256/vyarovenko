namespace OzonEdu.MerchandiseService.Models
{
    public sealed class MerchModel
    {
        /// <summary>
        /// Вид мерча:
        /// TShort , Sweatshirt, Notepad, Bag, Pen, Socks
        /// </summary>
        public string? ItemType { get; set; }
        /// <summary>
        /// Количество мерча
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Заметка по мерчу
        /// </summary>
        public string Tag { get; set; }
    }
}
