using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean.Inside.DAL.Repositories.RepositoryInterfaces
{
    using Ocean.Inside.DAL.Infrastructure;
    using Ocean.Inside.Domain.Entities;
    public class TestimonialRepository : RepositoryBase<Testimonial>, ITestimonialRepository
    {
        public TestimonialRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
