using System.Collections.Generic;
using Th.Music.BLL.Dtos.Song;

namespace Th.Music.BLL.Validators.Song
{
    public class SongValidator
    {
        //Fields
        SongDto _dto;
        List<string> _errors;

        //Properties
        public List<string> Errors { get => _errors; }
        public bool IsValid { get => _errors.Count == 0; }

        //Constructors
        public SongValidator(SongDto dto)
        {
            _dto = dto;
            _errors = new List<string>();
            Validate();
        }

        //Validate
        void Validate()
        {

        }
    }
}
