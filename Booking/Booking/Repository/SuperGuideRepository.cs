using Booking.Domain.Model;
using Booking.Domain.RepositoryInterfaces;
using Booking.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Repository
{
    public class SuperGuideRepository : ISuperGuideRepository
    {
        private const string FilePath = "../../Resources/Data/superGuide.csv";

        private readonly Serializer<SuperGuide> _serializer;

        public List<SuperGuide> _superGuides;

        public SuperGuideRepository()
        {
            _serializer = new Serializer<SuperGuide>();
            _superGuides = _serializer.FromCSV(FilePath);
        }

        public List<SuperGuide> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

        public SuperGuide GetSuperBySignedGuideId(int id)
        {
            foreach (var sg in _superGuides)
            {
                if (sg.Guide.Id == id)
                {
                    return sg;
                }
            }
            return null;
        }

        public int NextId()
        {
            if (_superGuides.Count == 0)
            {
                return 1;
            }
            else
            {
                return _superGuides.Max(t => t.Id) + 1;
            }
        }

        public void Add(SuperGuide guide)
        {
            guide.Id = NextId();
            _superGuides.Add(guide);
            _serializer.ToCSV(FilePath, _superGuides);
        }

        public void Delete(SuperGuide guide)
        {
            List<SuperGuide> _superGuideCopy = new List<SuperGuide>(_superGuides);

            _superGuides.Clear();
            foreach (var g in _superGuideCopy)
            {
                if (g.Id != guide.Id)
                {
                    _superGuides.Add(guide);
                }
            }
            _serializer.ToCSV(FilePath, _superGuides);
        }

        public void Update(SuperGuide updateGuide)
        {
            int index = _superGuides.FindIndex(u => u.Id == updateGuide.Id);
            _superGuides[index] = updateGuide;
            _serializer.ToCSV(FilePath, _superGuides);
        }

        public SuperGuide GetById(int id)
        {
            throw new NotImplementedException(); // not needed
        }
    }
}
