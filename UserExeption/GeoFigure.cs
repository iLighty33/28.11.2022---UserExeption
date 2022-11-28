using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserExeption
{
    // Task 2. GeoFigure

    internal class IncorrectValue : Exception
    {
        public IncorrectValue() { }
        public IncorrectValue(string message) : base(message) { }
        public IncorrectValue(string message, Exception innerException) : base(message, innerException) { }
    }
    public abstract class GeoFigure
    {
        public delegate void MyDelegate();

        protected string name;
        public string TypeOfObject { get; set; } = "Object" + DateTime.Now.ToString("yyyy.MM.dd-HH:mm:ss.fff");

        private bool Scalable;

        public bool scalable
        {
            get { return Scalable; }
            set { Scalable = value; }
        }

        public void PrintName()
        {
            Console.WriteLine(this.name);
        }
        public abstract float Square();
        public virtual float Square(float _metric)
        {
            return _metric;
        }
        public virtual float Square(float sideA, float sideB)
        {
            return sideA * sideB;
        }

        public abstract float Perimeter();

        public virtual float Perimeter(float _metric)
        {
            return _metric;
        }
        public virtual float Perimeter(float sideA, float sideB)
        {
            return sideA + sideB;
        }
    }
        // 01. Rectangle
        public class Rectangle : GeoFigure
        {
            public new string name = "Прямоугольник", _path = "output.txt";

            //public float _sideA, _sideB;

            public float _sideA
            {
                get { return _sideA; }
                set
                {
                    if(value < 0)
                    {
                        throw new IncorrectValue("Incorrect Value");
                    }
                    if (value == _sideB)
                    {
                        throw new IncorrectValue("This isn't a Cube, it's Rectangle");
                    }
                    _sideA = value;
                }
            }

            public float _sideB
            {
                get { return _sideB; }
                set
                {
                    if (value < 0)
                    {
                        throw new IncorrectValue("Incorrect Value");
                    }
                    if (value == _sideA)
                    {
                        throw new IncorrectValue("This isn't a Cube, it's Rectangle");
                    }
                    _sideB = value;
                }
            }

            public MyDelegate PrintRectanglePerimeter { get; private set; }

            public event MyDelegate _notify
            {
                add => _notify += value;
                remove => _notify -= value;
            }
            public override float Square()
            {
                float _result = _sideA * _sideB;
                float _limit = 100f;
                if (_result > _limit)
                {
                    _notify += InformerConsole;
                }
                return _result;
            }

            public float Square(float sideA, float sideB, bool isBase)
            {
                if (isBase)
                {
                    return base.Square(sideA, sideB);
                }
                {
                    return Square(sideA, sideB);
                }
            }
           
            public override float Perimeter()
            {
                float _result = _sideA * _sideB * 2.0f;

                return _result;
            }

            public override float Perimeter(float sideA, float sideB)
            {
                sideA = _sideA;
                sideB = _sideB;
                return sideA * sideB * 2.0f;
            }

            public float Perimeter(float sideA, float sideB, bool isBase)
            {
                if (isBase)
                {
                    return base.Perimeter(sideA, sideB);
                }
                {
                    return Perimeter(sideA, sideB);
                }
            }
            public void InformerConsole()
            {
                Console.WriteLine("Площадь треугольника больше 100");
            }

          
            public void PrintRectangleSquare()
            {
                Console.WriteLine($"Площадь = {this.Square()}");
            }
            public void PrintRectangleSquare(bool isBase)
            {
                Console.WriteLine($"Площадь = {this.Square(_sideA, _sideB, isBase)}");
            }
        }
        // 02. Triangle
        public class Triangle : GeoFigure
        {
            public Triangle()
            {
                name = "Треугольник";
            }
            public new string name = "Треугольник", _path = "output.txt";
            public event MyDelegate _notify;
            public float _sideA
            {
                get { return (float)_sideA; }
                set
                {
                    if (value < 0)
                    {
                        throw new IncorrectValue("Incorrect Value");
                    }
                if (value > _sideB + _sideC)
                {
                    throw new IncorrectValue("Value cannot be more then summary of two other");
                }
                _sideA = value;
                }
            }

            public float _sideB
            {
                get { return _sideB; }
                set
                {
                    if (value < 0)
                    {
                        throw new IncorrectValue("Incorrect Value");
                    }
                    if (value > _sideA + _sideC)
                    {
                        throw new IncorrectValue("Value cannot be more then summary of two other");
                    }
                    _sideB = value;
                }
            }

            public float _sideC
            {
                get { return _sideC; }
                set
                {
                    if (value < 0)
                    {
                        throw new IncorrectValue("Incorrect Value");
                    }
                    if (value > _sideA + _sideB)
                    {
                        throw new IncorrectValue("Value cannot be more then summary of two other");
                    }
                    _sideB = value;
                }
            }
            // Square
            public override float Square()
            {
                float _halfPerimeter = (_sideA + _sideB + _sideC) / 2;
                float _result = (float)Math.Sqrt (_halfPerimeter * (_halfPerimeter - _sideA) * (_halfPerimeter - _sideB) * (_halfPerimeter - _sideC));
                float _limit = 100f;
                if (_result > _limit)
                {
                    throw new IncorrectValue("Reach of Limit");
                }
                return _result;
            }


            public override float Perimeter()
            {
                float _result = _sideA + _sideB + _sideC;

                return _result;
            }

           
        }

        // 03. Circle
        public class Circle : GeoFigure
        {
            public new string name = "Круг", _path = "output.txt";

            public event MyDelegate _notify
            {
                add => _notify += value;
                remove => _notify -= value;
            }

            //public float _radius;

            public float _radius
            {
                get { return _radius; }
                set
                {
                    if (value < 0)
                    {
                        throw new IncorrectValue("Incorrect Value");
                    }

                    _radius = value;
                }
            }


            public override float Square()
            {
                //_notify = InformerConsole;

                float _result = _radius * _radius * 3.14f;
                float _limit = 100f;
                if (_result > _limit)
                {
                    throw new IncorrectValue("Out of Limits");
                }
                return _result;
            }

            public override float Perimeter()
            {
                float _result = _radius * _radius * 3.14f;

                return _result;
            }

            public override float Square(float _metric)
            {
                return _radius * _radius * 3.14f;
            }
            public float Square(float _metric, bool IsBase)
            {
                if (IsBase)
                {
                    return base.Square(_metric);
                }
                else
                {
                    return Square(_metric);
                }

            }
        }
    }



