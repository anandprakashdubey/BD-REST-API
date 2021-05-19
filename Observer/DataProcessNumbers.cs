using Observer.Repo;
using System;
using System.Collections.Generic;
 

namespace Observer
{
    public class DataProcessNumbers : IObserver
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int CurrentBatch { get; set; }
        public List<int> GeneratedNumberList { get; set; }
        public List<int> MultipliedNumberList { get; set; }
        public int RemainingBatch { get; set; }
        public DateTime LastUpdated { get; set; }       

        public void Update(ISubject _subject)
        {
            var subject = _subject as Subject;

            this.X = subject.X;
            this.Y = subject.Y;
            this.CurrentBatch = subject.CurrentBatch + 1;
            this.GeneratedNumberList = subject.GeneratedNumberList;
            this.MultipliedNumberList = subject.MultipliedNumberList;
            this.RemainingBatch = this.X - this.CurrentBatch;
            this.LastUpdated = DateTime.Now;           
        }

        //public void UpdateMultipliedNumbers(ISubject _subject)
        //{
        //    var subject = _subject as Subject;

        //    this.X = subject.X;
        //    this.Y = subject.Y;
        //    this.CurrentBatch = subject.CurrentBatch;           
        //    this.MultipliedNumberList = subject.MultipliedNumberList;
        //}

    }
}
