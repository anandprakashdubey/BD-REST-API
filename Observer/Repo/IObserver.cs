using System;
using System.Collections.Generic;
using System.Text;

namespace Observer.Repo
{
    public  interface IObserver
    {
        void Update(ISubject subject);
        //void UpdateMultipliedNumbers(ISubject subject);
    }
}