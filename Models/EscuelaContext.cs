using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebEscuela.Models
{
    public class EscuelaContext: DbContext
    {
        public DbSet<Escuela> Escuelas { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Evaluacion> Evaluaciones { get; set; }

        public EscuelaContext(DbContextOptions options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Creación de Escuelas
            var escuela1 = new Escuela();

            escuela1.Nombre = "UFG";
            escuela1.Id = Guid.NewGuid().ToString();
            escuela1.Fundacion = 1980;
            escuela1.Direccion = "San Salvador";
            escuela1.AtributoTipoDeEscuela = TiposEscuela.Superior;

            //Por cada escuela asignar Cursos

            var listaCursos = CargarCursos(escuela1);

            //Por cada Curso asignar Asignaturas

            var listaAsignaturas = CargarAsignaturas(listaCursos);

            //Por cada Curso asignar Alumnos

            var listaAlumnos = CargarAlumnos(listaCursos);

            //Por cada Alumno Asignar Evaluaciones

            var listaEvaluaciones = CargarEvaluaciones(listaAlumnos, listaAsignaturas);



            modelBuilder.Entity<Escuela>().HasData(escuela1);
            modelBuilder.Entity<Curso>().HasData(listaCursos);
            modelBuilder.Entity<Asignatura>().HasData(listaAsignaturas);
            modelBuilder.Entity<Alumno>().HasData(listaAlumnos);
            modelBuilder.Entity<Evaluacion>().HasData(listaEvaluaciones);
        }

        private static List<Asignatura> CargarAsignaturas(List<Curso> listaCursos)
        {
            var listaGeneral = new List<Asignatura>();

            foreach (var curso in listaCursos)
            {
                var listTmp = new List<Asignatura>()
                {
                    new Asignatura()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CursoId = curso.Id,
                        Nombre = "Programación"
                    },
                    new Asignatura()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CursoId = curso.Id,
                        Nombre = "Matemáticas"
                    },
                    new Asignatura()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CursoId = curso.Id,
                        Nombre = "Ciencias"
                    },
                    new Asignatura()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CursoId = curso.Id,
                        Nombre = "Lenguaje"
                    },
                };
                listaGeneral.AddRange(listTmp);
            }
            return listaGeneral;
        }

        private static List<Curso> CargarCursos(Escuela escuela1)
        {
            var ListaCursos = new List<Curso>() {
                new Curso()
                {
                    Id = Guid.NewGuid().ToString(),
                    EscuelaId = escuela1.Id,
                    Nombre = "Curso A"
                },

                new Curso()
                {
                    Id = Guid.NewGuid().ToString(),
                    EscuelaId = escuela1.Id,
                    Nombre = "Curso B"
                },
                new Curso()
                {
                    Id = Guid.NewGuid().ToString(),
                    EscuelaId = escuela1.Id,
                    Nombre = "Curso C"
                }
            };

            return ListaCursos;
        }

        private List<Alumno> CargarAlumnos(List<Curso> listaCurso)
        {
            var listaGeneral = new List<Alumno>();

            foreach (var curso in listaCurso)
            {
                var listaTmp = GenerarAlumnos(curso);
                listaGeneral.AddRange(listaTmp);
            }

            return listaGeneral;
        }

        private List<Alumno> GenerarAlumnos(Curso curso,int cantidad = 10)
        {
            string[] nombres = { "Ana", "Manuel", "Alejandro", "María", "Josue" };
            string[] apellidos = { "Martinez", "Nerio", "Guzman", "Maltez", "Cruz" };

            var listaAlumnos = from nom in nombres
                               from ape in apellidos
                               select new Alumno()
                               {
                                   CursoId = curso.Id,
                                   Id = Guid.NewGuid().ToString(),
                                   Nombre = $"{nom} {ape}"
                               };
            return listaAlumnos.OrderBy((al) => al.Id).Take(cantidad).ToList();
        }

        private List<Evaluacion> CargarEvaluaciones(List<Alumno> listaAlumnos, List<Asignatura> listaAsignaturas)
        {
            var listaGeneral = new List<Evaluacion>();

            foreach(var asignatura in listaAsignaturas)
            {
                foreach(var alumno in listaAlumnos)
                {
                    Random random = new Random();
                    double numero = random.NextDouble() * 9 + 1;

                    if (alumno.CursoId == asignatura.CursoId )
                    {
                        var listaTmp = new List<Evaluacion>()
                        {
                            new Evaluacion()
                            {
                                AlumnoId = alumno.Id,
                                AsignaturaId = asignatura.Id,
                                Nombre = asignatura.Nombre,
                                Nota = Math.Round(numero,1)
                            }

                        };
                        listaGeneral.AddRange(listaTmp);
                    }
                                       
                }
            }

            return listaGeneral;
        }

    }
}
