using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH06_Collections.CustomCollections
{
	using CH06_Collections.CustomCollections;
	using CH06_Collections.Models;
	using System.Collections;

	using BenchmarkDotNet.Attributes;
	using BenchmarkDotNet.Engines;
	using BenchmarkDotNet.Order;
	using CH06_Collections.Linq;
	using System.Collections.Generic;
	using System.Threading;

	[MemoryDiagnoser]
	[Orderer(SummaryOrderPolicy.FastestToSlowest)]
	[RankColumn]
	public class Catalogue
	{
		private Product[] Products = Array.Empty<Product>();

		[Benchmark]
		public void Add(Product product)
		{
			Products = Products.Append<Product>(product);
		}

		[Benchmark]
		public Product Get(int index)
		{
			return Products.Get<Product>(index);
		}

		[Benchmark]
		public int IndexOf(string match)
		{
			
			return Array.IndexOf<Product>(
				Products, 
				Products
					.Where(
						p => p.ToString().Contains(match)
					)
					.FirstOrDefault());
		}

		[Benchmark]
		public IEnumerator GetEnumerator()
		{
			return Products.GetEnumerator();
		}

		[Benchmark]
		public void Remove(int index)
		{
			Products = Products.Remove<Product>(index);
		}
	}
}
