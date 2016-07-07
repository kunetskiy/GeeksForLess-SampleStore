using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Xunit;

namespace GeeksForLess_SampleStore.Tests
{
    class Class1
    {
        public string Str { get; private set; }
    }

    class Class1Dto
    {
        public string Str { get; set; }
    }

    public class AutoMapperSpecs
    {
        [Fact]
        public void Is_it_possible_to_map_private_fields_with_automapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Class1Dto, Class1>();
            });

            var mapper = config.CreateMapper();
            var c1Dto = new Class1Dto { Str = "qweqwe" };
            var c1 = mapper.Map<Class1>(c1Dto);

            c1.Str.Should().Be(c1Dto.Str);
        }
    }
}
