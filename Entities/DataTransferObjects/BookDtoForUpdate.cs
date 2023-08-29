﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    //public record BookDtoForUpdate
    //{
    //    public int Id { get; init; }
    //    public string Title { get; init; }
    //    public decimal Price { get; init; }

    //}

    // böylede kullanılabilir
    public record BookDtoForUpdate:BookDtoForManipulation
    {
        [Required]
        public int Id { get; init; }
    }

}
