using System;
using System.Collections.Generic;
using System.Text;
using Models;
namespace Data
{
    public interface IUnitOfWork : Base.IUnitOfWork
    {
        IMenuRepository MenuRepository { get; }
        ICartRepository CartRepository { get; }
        // ICartItemRepository CartItemRepository { get; }
        IOrderRepository OrderRepository { get; }
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        //ICategotryToProductRepository CategotryToProductRepository { get; }
        IPersonRepository PersonRepository { get; }
        IContactRepository ContactRepository { get; }
        IOffCodeRepository OffCodeRepository { get; }
        IWeekDayRepository WeekDayRepository { get; }
        IRoleRepository RoleRepository { get; }
        IAboutUsRepository AboutUsRepository { get; }
        ISliderRepository SliderRepository { get; }
        public IProductGalleryRepository ProductGalleryRepository { get; }
        public IProductVisitRepository ProductVisitRepository { get;  }
        public IProductSelectedCategoryRepository ProductSelectedCategoryRepository { get; }
       

    }
}
