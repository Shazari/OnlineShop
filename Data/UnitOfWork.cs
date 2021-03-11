using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Models;
namespace Data
{
    public class UnitOfWork : Base.UnitOfWork, IUnitOfWork
    {
        public UnitOfWork(Options options) : base(options)
        {
        }

        private IMenuRepository _menuRepository;

        public IMenuRepository MenuRepository
        {
            get
            {
                if (_menuRepository == null)
                {
                    _menuRepository = new MenuRepository(DatabaseContext);
                }

                return _menuRepository;
            }
        }

        private ICartRepository _cartRepository;

        public ICartRepository CartRepository
        {
            get
            {
                if (_cartRepository == null)
                {
                    _cartRepository = new CartRepository(DatabaseContext);
                }

                return _cartRepository;
            }
        }

        //private ICartItemRepository _cartItemRepository;

        //public ICartItemRepository CartItemRepository
        //{
        //    get
        //    {
        //        if (_cartItemRepository == null)
        //        {
        //            _cartItemRepository =
        //                new CartItemRepository(DatabaseContext);
        //        }

        //        return _cartItemRepository;
        //    }
        //}


        private IOrderRepository _orderRepository;

        public IOrderRepository OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new OrderRepository(DatabaseContext);

                }

                return _orderRepository;
            }
        }

        private IProductRepository _productRepository;

        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository =
                        new ProductRepository(DatabaseContext);
                }

                return _productRepository;
            }
        }

        private ICategoryRepository _categotryRepository;

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categotryRepository == null)
                {
                    _categotryRepository =
                        new CategoryRepository(DatabaseContext);
                }

                return _categotryRepository;
            }
        }
        //public ICategoryToProductRepository CategotryToProductRepository => throw new NotImplementedException();
        //private ICategotryToProductRepository _categotryToProductRepository;

        //public ICategotryToProductRepository CategotryToProductRepository
        //{
        //    get
        //    {
        //        if (_categotryToProductRepository == null)
        //        {
        //            _categotryToProductRepository =
        //                new CategotryToProductRepository(DatabaseContext);
        //        }

        //        return _categotryToProductRepository;
        //    }
        //}
        // public IPersonRepository PersonRepository => throw new NotImplementedException();


        private IPersonRepository _personRepository;

        public IPersonRepository PersonRepository
        {
            get
            {
                if (_personRepository == null)
                {
                    _personRepository =
                        new PersonRepository(DatabaseContext);
                }

                return _personRepository;
            }
        }

        private IContactRepository _ContactRepository;
        public IContactRepository ContactRepository
        {
            get
            {
                if (_ContactRepository == null)
                {
                    _ContactRepository = new ContactRepository(DatabaseContext);
                }
                return _ContactRepository;
            }
        }
        private IOffCodeRepository _offCodeRepository;
        public IOffCodeRepository OffCodeRepository
        {
            get
            {
                if (_offCodeRepository == null)
                {
                    _offCodeRepository = new OffCodeRepository(DatabaseContext);
                }
                return _offCodeRepository;
            }
        }

        private IWeekDayRepository _weekDayRepository;
        public IWeekDayRepository WeekDayRepository
        {
            get
            {
                if (_weekDayRepository == null)
                {
                    _weekDayRepository = new WeekDayRepository(DatabaseContext);
                }

                return _weekDayRepository;
            }
        }

        private IRoleRepository _roleRepository;
        public IRoleRepository RoleRepository
        {
            get
            {
                if (_roleRepository == null)
                {
                    _roleRepository = new RoleRepository(DatabaseContext);
                }
                return _roleRepository;
            }
        }

        private IAboutUsRepository _aboutUsReposotory;
        public IAboutUsRepository AboutUsRepository
        {
            get
            {
                if (_aboutUsReposotory == null)
                {
                    _aboutUsReposotory = new AboutUsRepository(DatabaseContext);
                }
                return _aboutUsReposotory;
            }
        }

        private ISliderRepository _sliderRepository;
        public ISliderRepository SliderRepository
        {
            get
            {
                if (_sliderRepository == null)
                {
                    _sliderRepository = new SliderRepository(DatabaseContext);
                }
                return _sliderRepository;
            }
        }

        public IProductGalleryRepository _productGalleryRepository;
        public IProductGalleryRepository ProductGalleryRepository
        {
            get
            {
                if (_productGalleryRepository == null)
                {
                    _productGalleryRepository = new ProductGalleryRepository(DatabaseContext);

                }
                return _productGalleryRepository;
            }
        }

        private IProductVisitRepository _productVisitRepository;
        public IProductVisitRepository ProductVisitRepository
        {
            get
            {
                if (_productVisitRepository == null)
                {
                    _productVisitRepository = new ProductVisitRepository(DatabaseContext);
                }
                return _productVisitRepository;
            }
        }

        private IProductSelectedCategoryRepository _productSelectedCategoryRepository;
        public IProductSelectedCategoryRepository ProductSelectedCategoryRepository
        {
            get
            {
                if (_productSelectedCategoryRepository == null)
                {
                    _productSelectedCategoryRepository = new ProductSelectedCategoryRepository(DatabaseContext);
                }
                return _productSelectedCategoryRepository;
            }
        }

        public override async System.Threading.Tasks.Task SaveAsync()
        {
            await DatabaseContext.SaveChangesAsync();

        }


    }
}
