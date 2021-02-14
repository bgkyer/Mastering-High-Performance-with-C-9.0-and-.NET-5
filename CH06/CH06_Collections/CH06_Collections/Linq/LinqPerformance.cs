namespace CH06_Collections.Linq
{
	using BenchmarkDotNet.Attributes;
	using BenchmarkDotNet.Engines;
	using BenchmarkDotNet.Order;
	using CH06_Collections.CustomCollections;
	using System.Collections.Generic;
	using System.Linq;

	[MemoryDiagnoser]
	[Orderer(SummaryOrderPolicy.FastestToSlowest)]
	[RankColumn]
	public class LinqPerformance
	{
		private List<Person> _people;
		private List<string> _surnames;

		private string[] _group1 = new string[] { "iota", "epsilon", "sigma", "upsilon" };
		private string[] _group2 = new string[] { "alpha", "omega" };

		[GlobalSetup]
		public void PrepareBenchmarks()
		{
			_people = new List<Person>();
			_people.Add(new Person("Alpha", "Beta"));
			_people.Add(new Person("Chi", "Delta"));
			_people.Add(new Person("Epsilon", "Phi"));
			_people.Add(new Person("Gamma", "iota"));
			_people.Add(new Person("Kappa", "Lambda"));
			_people.Add(new Person("Mu", "Nu"));
			_people.Add(new Person("Omicron", "Pi"));
			_people.Add(new Person("Theta", "Rho"));
			_people.Add(new Person("Sigma", "Tau"));
			_people.Add(new Person("Upsilon", "Omega"));
			_people.Add(new Person("Xi", "Psi"));
			_people.Add(new Person("Zeta", "Iota"));
			_people.Add(new Person("Alpha", "Omega"));
			_people.Add(new Person("Omega", "Chi"));
			_people.Add(new Person("Sigma", "Tau"));

			_surnames = (from p in _people
						 select p.LastName).ToList();
		}

		[Benchmark]
		public List<Person> FilterGroupsVersion1()
		{
			return (from p in _people
					where _group1.Contains(p.LastName.ToLower())
					 || _group2.Contains(p.LastName.ToLower())
					select p).ToList();
		}

		[Benchmark]
		public List<Person> FilterGroupsVersion2()
		{
			return (from p in _people
					let lastName = p.LastName.ToLower()
					where _group1.Contains(lastName)
					|| _group2.Contains(lastName)
					select p).ToList();
		}

		[Benchmark]
		public List<Person> FilterGroupsVersion3()
		{
			List<Person> people = new List<Person>();
			for (int i = 0; i < _people.Count; i++)
			{
				var person = _people[i];
				var lastName = person.LastName.ToLower();
				if (
					_group1.Contains(lastName)
					|| _group2.Contains(lastName)
				)
					people.Add(person);
			}
			return people;
		}

		[Benchmark]
		public List<Person> FilterGroupsVersion4()
		{
			List<Person> people = new List<Person>();
			for (int i = 0; i < _people.Count; i++)
			{
				var person = _people[i];
				var lastName = person.LastName.ToLower();
				if (
					_group2.Contains(lastName)
					|| _group1.Contains(lastName)
				)
					people.Add(person);
			}
			return people;
		}

		[Benchmark]
		public Person GetLastPersonVersion1()
		{
			return _people.Last();
		}

		[Benchmark]
		public Person GetLastPersonVersion2()
		{
			return _people[_people.Count - 1];
		}

		[Benchmark]
		public List<Person> GroupByVersion1()
		{
			return _people
				.GroupBy(x => x.LastName)
				.Where(x => x.Count() > 1)
				.SelectMany(group => group)
				.ToList();
		}

		[Benchmark]
		public List<Person> GroupByVersion2()
		{
			IEnumerator<IGrouping<string, Person>> test = _people.GroupBy(p => p.LastName)
				.Where(p => p.Count() > 2).GetEnumerator();
			List<Person> people = new List<Person>();
			while (test.MoveNext())
			{
				IGrouping<string, Person> current = test.Current;
				foreach (Person person in current)
				{
					people.Add(person);
				}
			}
			return people;
		}

		[Benchmark]
		public List<Person> GroupByVersion3()
		{
			IEnumerator<IGrouping<string, Person>> test = _people.ToArray().GroupBy(p => p.LastName)
				.Where(p => p.Count() > 2).GetEnumerator();
			List<Person> people = new List<Person>();
			while (test.MoveNext())
			{
				var current = test.Current;
				foreach (var person in current)
				{
					people.Add(person);
				}
			}
			return people;
		}
	}
}
