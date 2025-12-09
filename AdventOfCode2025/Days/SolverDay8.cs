using AdventOfCode2025.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;

namespace AdventOfCode2025.Days
{
    internal class SolverDay8 : Solver
    {
        List<Vector3> _coords;
        Dictionary<(Vector3, Vector3), float> _distances;
        List<List<Vector3>> _circuits;

        public SolverDay8(string inputFile = "TestInput.txt", bool verbose = true)
        {
            _coords = new List<Vector3>();
            _distances = new Dictionary<(Vector3, Vector3), float> ();
            _circuits = new List<List<Vector3>>();

            _verbose = verbose;
            ReadInputFile(inputFile);
        }
        private void ReadInputFile(string inputFile)
        {
            FileReader fileReader = new FileReader(inputFile);
            while (!fileReader.EndOfStream)
            {
                var coord = fileReader.Read().Split(',').Select(x => x.Trim()).ToList();
                Vector3 point = new Vector3(long.Parse(coord[0]), long.Parse(coord[1]), long.Parse(coord[2]));
                _coords.Add(point);
            }
            
            fileReader.Close();
        }

        private void GetDistance()
        {
            for (int i = 0; i < _coords.Count; i++)
            {
                for (int j = i+1; j < _coords.Count; j++)
                {
                    float dist = Vector3.Distance(_coords[i], _coords[j]);
                    _distances.Add((_coords[i], _coords[j]), dist);
                }
            }
        }
        private (int,int) IsPresentInOneCircuit(Vector3 point1, Vector3 point2)
        {
            int ind1 = -1, ind2 = -1;
            foreach (var circuit in _circuits)
            {
                if (ind1 == -1 && circuit.Contains(point1))
                {
                    ind1 = _circuits.IndexOf(circuit);
                }
                if (ind2 == -1 && circuit.Contains(point2))
                {
                    ind2 = _circuits.IndexOf(circuit);
                }
                if (ind1 != -1 && ind2 != -1)
                    break;
            }
            return (ind1, ind2);
        }

        private void PrintCircuit()
        {
            int circuitNumber = 0;
            StringBuilder strb = new StringBuilder();
            strb.AppendLine("*****************");
            strb.AppendLine("List of Circuit : ");
            foreach (var circuit in _circuits)
            {
                strb.AppendLine($"Circuit [{circuitNumber}]");
                circuit.ForEach(x => strb.AppendLine(x.ToString()));
                strb.AppendLine("End of circuit");
                strb.AppendLine();
                circuitNumber++;
            }
            strb.AppendLine("*****************");
            Console.WriteLine(strb.ToString());
        }

        public override long GetSolution1Star()
        {
            GetDistance();
            int numberOfConnexion = 0;
            foreach(var dist in _distances.OrderBy(key => key.Value))
            {
                
                StringBuilder strb = new StringBuilder();
                bool connect = false;
                (int,int) index = IsPresentInOneCircuit(dist.Key.Item1, dist.Key.Item2);
                if (_verbose)
                    strb.Append($"Connect {dist.Key.Item1} - {dist.Key.Item2} (dist : {dist.Value}) => ");
                if (index.Item1 == -1 && index.Item2 == -1)
                {
                    if (_verbose)
                        strb.Append(" New Circuit Created;");
                    List<Vector3> circuit = new List<Vector3>();
                    circuit.Add(dist.Key.Item1);
                    circuit.Add(dist.Key.Item2);
                    _circuits.Add(circuit);
                    connect = true;
                }
                else if (index.Item2 == -1)
                {
                    if (_verbose)
                        strb.Append($" Added to circuit number {index.Item1}.");
                    _circuits[index.Item1].Add(dist.Key.Item2);
                    connect = true;
                }
                else if (index.Item1 == -1)
                {
                    if (_verbose)
                        strb.Append($" Added to circuit number {index.Item2}.");
                    _circuits[index.Item2].Add(dist.Key.Item1);
                    connect = true;
                }
                else if (index.Item1 != index.Item2)
                {
                    if (_verbose)
                        strb.Append($" Merge circuit {index.Item1} & circuit {index.Item2}.");
                    var mergedCircuit = _circuits[index.Item1].Union(_circuits[index.Item2]).ToList();
                    if (index.Item2 > index.Item1)
                    {
                        _circuits.Remove(_circuits[index.Item2]);
                        _circuits.Remove(_circuits[index.Item1]);
                    }
                    else
                    {
                        _circuits.Remove(_circuits[index.Item1]);
                        _circuits.Remove(_circuits[index.Item2]);
                    }
                    _circuits.Add(mergedCircuit);
                    connect = true;
                    numberOfConnexion++;
                    
                }
                else
                {
                    if (_verbose)
                        strb.Append($" Already in circuit {index.Item2}.");
                }
                if (_verbose)
                {
                    strb.AppendLine();
                    Console.WriteLine(strb.ToString());
                }
                if (connect)
                    numberOfConnexion++;
                if (numberOfConnexion >= 1000)
                    break;
            }
            if (_verbose)
                PrintCircuit();
            int numberOfLargestCircuit = 0;
            long solution = 1;
            foreach (var circuit in _circuits.OrderByDescending(x => x.Count))
            {
                solution *= circuit.Count;
                numberOfLargestCircuit++;
                if (numberOfLargestCircuit >= 3)
                    break;
            }
            foreach (var item in _circuits.OrderByDescending(x => x.Count))
            {
                Console.WriteLine(item.Count);
            }
            return solution;
        }
    }
}
