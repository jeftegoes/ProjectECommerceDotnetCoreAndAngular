using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class LojaContextSeed
    {
        public static async Task SeedAsync(LojaContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.MarcaProduto.Any())
                {
                    var marcasProdutoData = File.ReadAllText("../Infrastructure/Data/SeedData/marcasProduto.json");

                    var marcasProduto = JsonSerializer.Deserialize<List<MarcaProduto>>(marcasProdutoData);

                    foreach (var marca in marcasProduto)
                    {
                        context.MarcaProduto.Add(marca);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.TipoProduto.Any())
                {
                    var tiposProdutoData = File.ReadAllText("../Infrastructure/Data/SeedData/tiposProduto.json");

                    var tiposProduto = JsonSerializer.Deserialize<List<TipoProduto>>(tiposProdutoData);

                    foreach (var tipo in tiposProduto)
                    {
                        context.TipoProduto.Add(tipo);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Produto.Any())
                {
                    var produtosData = File.ReadAllText("../Infrastructure/Data/SeedData/produtos.json");

                    var produtos = JsonSerializer.Deserialize<List<Produto>>(produtosData);

                    foreach (var produto in produtos)
                    {
                        context.Produto.Add(produto);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<LojaContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}