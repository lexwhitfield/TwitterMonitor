using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterMonitor.DataAccess.Interfaces;
using TwitterMonitor.DataAccess.Repositories;
using TwitterMonitor.Services.Interfaces;
using TwitterMonitor.Transform;
using TwitterMonitor.ViewModels;

namespace TwitterMonitor.Services.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService()
        {
            _eventRepository = new EventRepository();
        }

        public async Task<IEnumerable<EventViewModel>> GetAll()
        {
            var events = await _eventRepository.GetAll();
            return events.Select(ModelTransformer.EventToEventViewModel);
        }

        public async Task<EventViewModel> GetById(int id)
        {
            var events = await _eventRepository.GetById(id);
            return ModelTransformer.EventToEventViewModel(events);
        }

        public async Task<EventViewModel> Add(EventViewModel eventViewModel)
        {
            var events = await _eventRepository.Add(ModelTransformer.EventViewModelToEvent(eventViewModel));
            return ModelTransformer.EventToEventViewModel(events);
        }

        public async Task<EventViewModel> Update(EventViewModel eventViewModel)
        {
            var original = await _eventRepository.GetById(eventViewModel.Id.Value);
            var events = await _eventRepository.Update(ModelTransformer.EventViewModelToEvent(eventViewModel, original));
            return ModelTransformer.EventToEventViewModel(events);
        }

        public async Task<bool> Delete(int id)
        {
            var success = await _eventRepository.Delete(id);
            return success;
        }
    }
}
