using System;
using System.Collections.Generic;
using System.Text;

namespace Th.Music.BLL.Validators
{
    public abstract class BaseValidator
    {
        public bool Failed { get => Errors.Count > 0; }
        public bool Succeed { get => Errors.Count == 0; }
        public virtual List<string> Errors { get; set; } = new List<string>();
    }
}
