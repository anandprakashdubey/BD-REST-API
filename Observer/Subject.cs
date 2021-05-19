using Observer.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    public class Subject : ISubject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int CurrentBatch { get; set; }
        public List<int> GeneratedNumberList { get; set; }
        public List<int> MultipliedNumberList { get; set; }

        private List<IObserver> _observers = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            this._observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);
        }

        public void NotifyGeneratedNumbers()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

        public void NotifyMultipliedNumbers()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

        public void GeneratedNumbers(int x, int y, int _currentBatch)
        {
            this.X = x;
            this.Y = y;
            this.CurrentBatch = _currentBatch;            
            this.NotifyGeneratedNumbers();
        }

        public void MultipliedNumbers(int x, int y, int _currentBatch)
        {
            this.X = x;
            this.Y = y;
            this.CurrentBatch = _currentBatch;
            this.NotifyMultipliedNumbers();
        }
    }
}
