using Admin.Base.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Base.Services
{
    public interface IPlatformService
    {
        void RunOnUIThread(Action action);
        bool IsUIThread { get; }
        PageOrientation CurrentOrientation { get; }
        void SetCurrentOrientation(PageOrientation currentOrientation);
    }
}
