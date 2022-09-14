using FluentAssertions;
using PlataformaCurso.Test._Util;
using System;
using Xunit;

namespace PlataformaCurso.Test.Cursos
{
    public class CursoTest
    {
        [Fact]
        public void ShouldCreateCourse()
        {
            var cursoEsperado = new
            {
                Nome = "Info basica",
                CargaHoraria = (double)20.2,
                PublicoAlvo = PublicAlvo.Estudante,
                Valor = (double)200.00,
            };

            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            cursoEsperado.Should().BeEquivalentTo(curso);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void NaoDeveCursoTerUmNomeInvalido(string nomeInvalido)
        {
            var cursoEsperado = new
            {
                Nome = "Info basica",
                CargaHoraria = (double)20.2,
                PublicoAlvo = PublicAlvo.Estudante,
                Valor = (double)200.00,
            };

            Assert.Throws<ArgumentException>(() => new Curso(nomeInvalido, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor)).ComMensagem("Nome inválido");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerUmaCargaHorariaMenorQueUm(double carga)
        {
            var cursoEsperado = new
            {
                Nome = "Info basica",
                CargaHoraria = (double)20.2,
                PublicoAlvo = PublicAlvo.Estudante,
                Valor = (double)200.00,
            };

            Assert.Throws<ArgumentException>(() => new Curso(cursoEsperado.Nome, carga, cursoEsperado.PublicoAlvo, cursoEsperado.Valor)).ComMensagem("Carga horária inválida");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerUmaValorMenorQueUm(double valor)
        {
            var cursoEsperado = new
            {
                Nome = "Info basica",
                CargaHoraria = (double)20.2,
                PublicoAlvo = PublicAlvo.Estudante,
                Valor = (double)200.00,
            };

            Assert.Throws<ArgumentException>(() => new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, valor)).ComMensagem("Valor inválido");
        }
    }

    public enum PublicAlvo
    {
        Estudante,
        Universitario,
        Empregado,
        Empreendedor
    }

    public class Curso
    {
        public Curso(string nome, double carga, PublicAlvo publico, double valor)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome inválido");

            if(carga < 1)
                throw new ArgumentException("Carga horária inválida");

            if (valor < 1)
                throw new ArgumentException("Valor inválido");

            Nome =nome;
            CargaHoraria=carga;
            PublicoAlvo=publico;
            Valor=valor;
        }
        public string? Nome;
        public double CargaHoraria;
        public PublicAlvo PublicoAlvo;
        public double Valor;

    }
}
