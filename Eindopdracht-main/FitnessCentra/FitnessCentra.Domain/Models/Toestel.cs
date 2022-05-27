
using FitnessCentra.Domain.Interfaces;
using FitnessCentra.Domain.Models;
using System;
using System.Linq.Expressions;

public class Toestel 
{
	//private bool _isBeschikbaar = true;
    public int Id { get; set; }
    public string Type { get; set; }
    public DateTime OnderhoudsDatum { get; set; }
    public DateTime VerwijderingsDatum { get; set; }

    public bool OnderhoudBijVolgendeVrijStelling = false;
    public bool VerwijderBijVolgendeVrijStelling = false;

    
	//static List<int> _idsInGebruik = new List<int>();
	public Toestel(int id, string type, bool onderhoud=false, bool verwijdering=false) {

		Id = id;
		Type = type;
        OnderhoudBijVolgendeVrijStelling = onderhoud;
        VerwijderBijVolgendeVrijStelling = verwijdering;


    }

    public override string? ToString()
    {
        return $"{Type} - {Id}";
    }
   
    public override bool Equals(object? obj)
    {
        return obj is Toestel toestel &&
               Id == toestel.Id;
    }

    public override int GetHashCode()
    {
        return Id;
    }
}
