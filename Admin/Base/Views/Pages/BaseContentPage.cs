using Admin.Base.Services;
using Admin.Base.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Admin.Base.Pages
{
    public abstract class BaseContentPage : ContentPage
    {
        public static IPlatformService PlatformService => Xamarin.Forms.DependencyService.Get<IPlatformService>();

        bool _isFirstAppeared = true;

        private double _width;
        private double _height;

        protected PageOrientation CurrentOrientation;

        public EventHandler<PageOrientation> OnOrientationChanged = (e, a) => { };

        public BaseContentPage()
        {
        }

        protected virtual void OnBackResume()
        {
        }

        protected override void OnAppearing()
        {
            if (_isFirstAppeared)
            {
                _isFirstAppeared = false;
            }
            else
            {
                OnBackResume();
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            var oldWidth = _width;
            const double sizenotallocated = -1;

            base.OnSizeAllocated(width, height);
            if (Equals(_width, width) && Equals(_height, height)) return;

            _width = width;
            _height = height;

            // ignore if the previous height was size unallocated
            if (Equals(oldWidth, sizenotallocated)) return;

            // Has the device been rotated ?
            if (!Equals(width, oldWidth))
            {
                CheckAndChangeLayout();
            }
        }

        private void CheckAndChangeLayout()
        {
            if (_width < _height)
            {
                ChangeLayoutAndInvoke(PageOrientation.Vertical);
            }
            else
            {
                ChangeLayoutAndInvoke(PageOrientation.Horizontal);
            }
        }

        private void ChangeLayoutAndInvoke(PageOrientation pageOrientation)
        {

            if (!pageOrientation.Equals(CurrentOrientation))
            {
                CurrentOrientation = pageOrientation;

                switch (pageOrientation)
                {
                    case PageOrientation.Vertical:
                        SetupPortraitLayout();
                        break;
                    case PageOrientation.Horizontal:
                        SetupLandscapeLayout();
                        break;
                    default:
                        break;
                }
                OnOrientationChanged?.Invoke(this, pageOrientation);
                PlatformService?.SetCurrentOrientation(pageOrientation);
            }
            else
            {
                //do nothing
            }
        }

        protected abstract void SetupLandscapeLayout();
        protected abstract void SetupPortraitLayout();
    }
}

