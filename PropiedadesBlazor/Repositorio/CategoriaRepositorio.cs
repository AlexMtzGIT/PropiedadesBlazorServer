using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PropiedadesBlazor.Data;
using PropiedadesBlazor.Modelos;
using PropiedadesBlazor.Modelos.DTO;
using PropiedadesBlazor.Repositorio.IRepositorio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PropiedadesBlazor.Repositorio
{
    public class CategoriaRepositorio : ICategoriaRepositorio //": ICategoriaRepositorio" implementa o hereda de ICategoriaRepositorio
    {

        private readonly ApplicationDbContext _bd;//se guarda en "_bd" nombre que le ponemos nosotros
        private readonly IMapper _mapper; //también instanciamos el IMapper en "_mapper"

        public CategoriaRepositorio(ApplicationDbContext bd, IMapper mapper)//este es el constructor de esta clase, recibimos "ApplicationDbContext bd" como parametro (esto es implementar la inyeccion de dependencias) 
        {
            _bd = bd;
            _mapper = mapper;
            //ahora podemos acceder a las tablas de la base de datos con bd
        }

        public async Task<CategoriaDTO> ActualizarCategoria(int categoriaId, CategoriaDTO categoriaDTO)
        {
            try
            {
                if (categoriaId == categoriaDTO.Id)//Valida que las dos ID sean las mismas
                {
                    //Valido para actualizar
                    Categoria categoria = await _bd.Categorias.FindAsync(categoriaId);//Aqui obtenemos la categoria que se va a actualizar
                    Categoria cate = _mapper.Map<CategoriaDTO, Categoria>(categoriaDTO, categoria);
                    cate.FechaActualizacion = DateTime.Now;
                    var categoriaActualizada = _bd.Categorias.Update(cate);//se crea la variable "categoriaActualizada" la cual es igual al proceso de actualizar (Update)
                    await _bd.SaveChangesAsync();//metodo (ya default) que sirve para guardar los cambios
                    return _mapper.Map<Categoria, CategoriaDTO>(categoriaActualizada.Entity);

                }
                else
                {
                    //Invalido = no se encuentra el Id de la Categoria
                    return null;
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<int> BorrarCategoria(int categoriaId)
        {
            var categoria = await _bd.Categorias.FindAsync(categoriaId);
            if(categoria != null)
            {
                _bd.Categorias.Remove(categoria);
                return await _bd.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<CategoriaDTO> CrearCategoria(CategoriaDTO categoriaDTO)
        {
            Categoria categoria = _mapper.Map<CategoriaDTO, Categoria>(categoriaDTO);
            categoria.FechaCreacion = DateTime.Now;
            var categoriaAgregada = await _bd.Categorias.AddAsync(categoria);//creamos la variable "categoriaAgregada" la cual es igual al proceso de crear en segundo plano (AddAsync)
            await _bd.SaveChangesAsync();
            return _mapper.Map<Categoria, CategoriaDTO>(categoriaAgregada.Entity);
        }

        public async Task<IEnumerable<CategoriaDTO>> GetAllCategorias()//este metodo es para mostrar las categorias en forma de lista
        {
            try
            {
                IEnumerable<CategoriaDTO> categoriaDTO = _mapper.Map<IEnumerable<Categoria>, IEnumerable<CategoriaDTO>>(_bd.Categorias);
                return (categoriaDTO);
            }
            catch (Exception ex)//"ex" es una variable creada
            {

                return null;
            }
        }

        public async Task<CategoriaDTO> GetCategoria(int categoriaId)
        {
            try
            {
                CategoriaDTO categoriaDTO = _mapper.Map<Categoria, CategoriaDTO>(await _bd.Categorias.FirstOrDefaultAsync(c => c.Id == categoriaId));
                return (categoriaDTO);
            }
            catch (Exception ex)//"ex" es una variable creada
            {

                return null;
            }
        }

        public async Task<CategoriaDTO> NombreCategoriaExiste(string nombre)
        {
            try
            {
                CategoriaDTO categoriaDTO = _mapper.Map<Categoria, CategoriaDTO>(await _bd.Categorias.FirstOrDefaultAsync(c => c.NombreCategoria.ToLower() == nombre.ToLower()));
                return categoriaDTO;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
