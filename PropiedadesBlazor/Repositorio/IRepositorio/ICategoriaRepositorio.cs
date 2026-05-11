using PropiedadesBlazor.Modelos.DTO;

namespace PropiedadesBlazor.Repositorio.IRepositorio
{
    public interface ICategoriaRepositorio
    {
        public Task<IEnumerable<CategoriaDTO>> GetAllCategorias(); //"GetAllCategorias();" es el nombre del metodo (aqui se creá), este metodo es para obtener una lista de todas las Categorias
        public Task<CategoriaDTO> GetCategoria(int categoriaId);//"GetCategoria();" es el nombre del metodo (aqui se creá), este metodo es para obtener una Categoria en especificom usando la llame primaria del Id, (aqui el id lo declaramos como "categoriaId")
        public Task<CategoriaDTO> CrearCategoria(CategoriaDTO categoriaDTO);//"CrearCategoria" es el nombre del metodo para crear una categoria (aqui se creó el metodo), este metodo recibe un objeto de "CategoriaDTO" y lo guarda en "categoriaDTO" (este ultimo le declaramos el nombre aqui)
        public Task<CategoriaDTO> ActualizarCategoria(int categoriaId, CategoriaDTO categoriaDTO);////"ActualizarCategoria" es el nombre del metodo para aztualizar una categoria (aqui se creó el metodo), este metodo recibe: el categoriaId para saber cual categoria se actualizara, un objeto de "CategoriaDTO" y lo guarda en "categoriaDTO" (este ultimo le declaramos el nombre aqui)
        public Task<int> BorrarCategoria(int categoriaId);
        public Task<CategoriaDTO> NombreCategoriaExiste(string nombre);//Metodo que verifica si la categoria ya existe

        //public Task<IEnumerable<CategoriaDTO>> GetDropDownCategorias();//Metodo que crea una lista de selección html, basicamente una lista desplegable que enseñe la lista de categorias, "GetDropDownCategorias" es el nombre

    }
}
