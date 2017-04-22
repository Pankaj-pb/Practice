using System;
using System.Threading;

namespace WebApplication5
{
    public class TestDelegate
    {
        public delegate void SaveButtonClickHandlerDelegate(object source, EventArgs e);

        public event SaveButtonClickHandlerDelegate SaveButtonClicked;

        public void EventHappened(SaveEventClickArgs s)
        {
            Thread.Sleep(3000);
            OnSaveButtonClicked(s);
        }
        public void OnSaveButtonClicked(SaveEventClickArgs e)
        {
            if (SaveButtonClicked != null)
            {
                SaveButtonClicked(this, e);
            }
        }
    }

    public class SaveEventClickArgs : EventArgs
    {
        public bool Cancel { get; set; }

        public SaveEventClickArgs()
        {
            Cancel = false;
        }
    }
}