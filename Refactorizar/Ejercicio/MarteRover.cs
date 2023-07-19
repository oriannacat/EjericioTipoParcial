using System.Linq;

namespace EjercicioTipoParcial.Ejercicio
{
    public class MarteRover
    {
        private int _x;
        private int _y;
        public char _direccion { get; set; }
        public bool _obstaculoEncontrado { get; set; }
        public string[] _obstaculos { get; set; }

        private readonly string _direccionesDisponibles = "NESW";

        public MarteRover(int x, int y, char direccion, string[] cadena)
        {
            _x = x;
            _y = y;
            _direccion = direccion;
            _obstaculos = cadena;
        }
        
        public string ObtenerEstado()
        {
            return !_obstaculoEncontrado ? $"{_x}:{_y}:{_direccion}" : $"O:{_x}:{_y}:{_direccion}";
        }

        public void Ejecutar(string commands)
        {
            foreach(char command in commands)
            {
                if (command == 'M')
                {
                    EjecutarComandoM(_direccion);
                }
                else 
                {
                    if (command == 'L') 
                    {
                        EjecutarComandoL(_direccion);
                    }
                    else 
                    {
                        if (command == 'R')
                        {
                            EjecutarComandoR(_direccion);
                        }
                    }
                }
            }

        }

        public void EjecutarComandoM(char direccion) 
        {
            switch (_direccion)
            {
                case 'E':
                    _obstaculoEncontrado = _obstaculos.Contains($"{_x + 1}:{_y}");
                    // comprobar si el vehículo ha alcanzado el límite de la meseta o ha encontrado un obstáculo
                    _x = _x < 9 && !_obstaculoEncontrado ? _x += 1 : _x;
                    break;
                case 'S':
                    _obstaculoEncontrado = _obstaculos.Contains($"{_x}:{_y + 1}");
                    // comprobar si el vehículo ha alcanzado el límite de la meseta o ha encontrado un obstáculo
                    _y = _y < 9 && !_obstaculoEncontrado ? _y += 1 : _y;
                    break;
                case 'W':
                    _obstaculoEncontrado = _obstaculos.Contains($"{_x - 1}:{_y}");
                    // comprobar si el vehículo ha alcanzado el límite de la meseta o ha encontrado un obstáculo
                    _x = _x > 0 && !_obstaculoEncontrado ? _x -= 1 : _x;
                    break;
                case 'N':
                    _obstaculoEncontrado = _obstaculos.Contains($"{_x}:{_y - 1}");
                    // comprobar si el vehículo ha alcanzado el límite de la meseta o ha encontrado un obstáculo
                    _y = _y > 0 && !_obstaculoEncontrado ? _y -= 1 : _y;
                    break;
            }
        }

        public void EjecutarComandoL(char direc) 
        {
            // obtener una nueva dirección
            var currentDirectionPosition = _direccionesDisponibles.IndexOf(direc);
            if (currentDirectionPosition != 0)
            {
                direc = _direccionesDisponibles[currentDirectionPosition - 1];
            }
            else
            {
                direc = _direccionesDisponibles[3];
            }
        }
        public void EjecutarComandoR(char direc) 
        {
            // obtener una nueva dirección
            var currentDirectionPosition = _direccionesDisponibles.IndexOf(direc);
            if (currentDirectionPosition != 3)
            {
                direc = _direccionesDisponibles[currentDirectionPosition + 1];
            }
            else
            {
                direc = _direccionesDisponibles[0];
            }
        }
    }
}