using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eventyr.EndlessRunner.Scripts.Interfaces
{
    public interface IUserData
    {
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public int MaxScore { get; set; }
    }
}
