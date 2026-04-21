using AutoMapper;
using PropiedadesBlazor.Modelos;
using PropiedadesBlazor.Modelos.DTO;

namespace PropiedadesBlazor.Mapper
{
    public class PerfilMapa : Profile
    {
        //aqui se crea el constructor de la clase "PerfilMapa"
        public PerfilMapa() 
        {
            CreateMap<CategoriaDTO, Categoria>(); //aqui se vincula CategoriaDTO con Categoria
            CreateMap<Categoria, CategoriaDTO>(); //aqui se vincula Categoria con CategoriaDTO (conectados por los dos lados)
        }
    }
}
