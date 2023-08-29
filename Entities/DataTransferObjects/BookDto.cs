﻿namespace Entities.DataTransferObjects
{
    //[Serializable]
    //public record BookDto(int id, string Title, decimal Price);

    public record BookDto
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public decimal Price { get; init; }

    }

}
 