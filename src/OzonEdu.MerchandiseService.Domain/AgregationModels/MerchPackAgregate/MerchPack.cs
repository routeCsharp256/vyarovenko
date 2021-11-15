using OzonEdu.MerchandiseService.Domain.AgregationModels.MerchItemAgregate;
using OzonEdu.MerchandiseService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Domain.AgregationModels.MerchPackAgregate
{
    /// <summary>
    /// Комплект мерча
    /// </summary>
    public class MerchPack : Entity, IAggregateRoot
    {
        /// <summary>
        /// Мерч, входящий в комплект
        /// </summary>
        private List<MerchItem> MerchItems { get; set; }

        public int Count { get => MerchItems.Count; }

        public MerchPack()
        {
            MerchItems = new List<MerchItem>();
        }

        public MerchPack(IEnumerable<MerchItem> merchItems)
        {
            if (merchItems is null) throw new ArgumentNullException("Merch Items is null");
            MerchItems = new List<MerchItem>(merchItems);
        }

        public MerchPack(params MerchItem[] merchItems)
        {
            if (merchItems is null) throw new ArgumentNullException("Merch Items is null");
            MerchItems = new List<MerchItem>(merchItems);
        }

        /// <summary>
        /// Добавить мерч в пакет
        /// </summary>
        /// <param name="merchItems">Мерч</param>
        public void AddMerch(params MerchItem[] merchItems)
        {
            if (merchItems is null) throw new ArgumentNullException("Merch Items is null");
            MerchItems.AddRange(merchItems);
        }

        public List<MerchItem> GetItems()
        {
            return MerchItems;
        }

        /// <summary>
        /// Получить Welcome Pack
        /// </summary>
        public static MerchPack GetWelcomePack(ClouthingSize size)
        {
            var notepads = MerchItem.GetNotepad(2);
            var pen = MerchItem.GetPen();
            var tShort = MerchItem.GetTShort(size);
            return new MerchPack(notepads, pen, tShort);
        }

        /// <summary>
        /// Получить Starter Pack
        /// </summary>
        public static MerchPack GetStarterPack(ClouthingSize size)
        {
            var notepads = MerchItem.GetNotepad(3);
            var pens = MerchItem.GetPen(2);
            var tShort = MerchItem.GetTShort(size);
            var socks = MerchItem.GetSocks(3);
            var bag = MerchItem.GetBag();
            return new MerchPack(notepads, pens, tShort, socks, bag);
        }

        /// <summary>
        /// Получить Conference Listener Pack
        /// </summary>
        public static MerchPack GetConferenceListenerPack()
        {
            var notepad = MerchItem.GetNotepad();
            var pen = MerchItem.GetPen();
            return new MerchPack(notepad, pen);
        }

        /// <summary>
        /// Получить Conference Speaker Pack
        /// </summary>
        public static MerchPack GetConferenceSpeakerPack(ClouthingSize size)
        {
            var notepad = MerchItem.GetNotepad();
            var pen = MerchItem.GetPen();
            var tShort = MerchItem.GetTShort(size);
            var sweashirt = MerchItem.GetSweatshirt(size);
            return new MerchPack(notepad, pen, tShort, sweashirt);
        }

        /// <summary>
        /// Получить Veteran Pack
        /// </summary>
        public static MerchPack GetVeteranPack(ClouthingSize size)
        {
            var notepads = MerchItem.GetNotepad(3);
            var pens = MerchItem.GetPen(5);
            var tShorts = MerchItem.GetTShort(size, 3);
            var sweashirts = MerchItem.GetSweatshirt(size, 2);
            var socks = MerchItem.GetSocks(10);
            var bags = MerchItem.GetBag(3);
            return new MerchPack(notepads, pens, tShorts, sweashirts, socks, bags);
        }
    }
}
