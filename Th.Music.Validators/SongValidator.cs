using System;
using System.Collections.Generic;
using System.Text;
using Th.Music.Dtos;
using Th.Music.IServices;
using Th.Music.Response;

namespace Th.Music.Validators
{
    public class SongValidator
    {
        //Fields
        SongDto _dto;
        List<string> _errors;

        //Properties
        public List<string> Errors { get => _errors; }
        public bool IsValid { get => _errors.Count > 0; }

        //Constructors
        public SongValidator(SongDto dto)
        {
            _dto = dto;
            _errors = new List<string>();
        }

        //Validate
        void Validate(SongDto _dto)
        {

        }
    }
}
