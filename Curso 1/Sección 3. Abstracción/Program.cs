namespace Sección_3._Abstracción;

class Program
{
    
    public interface IAnimal
    {
        public void comer();
        public void dormir();
        public void moverse();
    }

    public class Carnivoro: IAnimal
    {
        public void comer()
        {
            Console.WriteLine("Carnivoro comer");
        }

        public void comer(String comida)
        {
            Console.WriteLine("Carnivoro comer " + comida);
        }

        public void dormir()
        {
            throw new NotImplementedException();
        }

        public void moverse()
        {
            throw new NotImplementedException();
        }
    }

    public class Hervivoro : IAnimal
    {
        public void comer()
        {
            Console.WriteLine("Hervivoro comer");
        }

        public void dormir()
        {
            throw new NotImplementedException();
        }

        public void moverse()
        {
            throw new NotImplementedException();
        }
    }
    
    
    static void Main(string[] args)
    {
        Carnivoro c = new Carnivoro();
        c.comer();
    }
}