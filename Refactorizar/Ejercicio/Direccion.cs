using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioTipoParcial.Ejercicio
{
    public abstract class Direccion
    {
        public void Mover(int horizontal, int vertical) { }
    }

    public class Norte : Direccion
    {

        public void Mover(int horizontal, int vertical, bool _obstaculoEncontrado, string[] _obstaculos)
        {
            _obstaculoEncontrado = _obstaculos.Contains($"{horizontal}:{vertical - 1}");
            // comprobar si el vehículo ha alcanzado el límite de la meseta o ha encontrado un obstáculo
            vertical = vertical > 0 && !_obstaculoEncontrado ? vertical -= 1 : vertical;
        }
    }

    public class Sur : Direccion
    {
        public void Mover(int horizontal, int vertical, bool _obstaculoEncontrado, string[] _obstaculos)
        {
            _obstaculoEncontrado = _obstaculos.Contains($"{horizontal}:{vertical + 1}");
            // comprobar si el vehículo ha alcanzado el límite de la meseta o ha encontrado un obstáculo
            vertical = vertical < 9 && !_obstaculoEncontrado ? vertical += 1 : vertical;
        }
    }

    public class Este : Direccion
    {
        public void Mover(int horizontal, int vertical, bool _obstaculoEncontrado, string[] _obstaculos)
        {
            _obstaculoEncontrado = _obstaculos.Contains($"{horizontal + 1}:{vertical}");
            // comprobar si el vehículo ha alcanzado el límite de la meseta o ha encontrado un obstáculo
            horizontal = horizontal < 9 && !_obstaculoEncontrado ? horizontal += 1 : horizontal;
        }
    }

    public class Oeste : Direccion
    {
        public void Mover(int horizontal, int vertical, bool _obstaculoEncontrado, string[] _obstaculos)
        {
            _obstaculoEncontrado = _obstaculos.Contains($"{horizontal - 1}:{vertical}");
            // comprobar si el vehículo ha alcanzado el límite de la meseta o ha encontrado un obstáculo
            horizontal = horizontal > 0 && !_obstaculoEncontrado ? horizontal -= 1 : horizontal;
        }
    }
}
