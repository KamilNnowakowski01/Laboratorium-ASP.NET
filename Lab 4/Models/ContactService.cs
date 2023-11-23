namespace Lab_4.Models
{
    public class ContactService : IContactService
    {
        private Dictionary<int, Contact> _contacts = new Dictionary<int, Contact>();
        private readonly IDateTimeService _dateTimeService;

        public ContactService(IDateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService;
        }

        public int Add(Contact model)
        {
            int id = _contacts.Keys.Count != 0 ? _contacts.Keys.Max() : 0;
            model.Id = id + 1;
            model.Created = _dateTimeService.getCurrentDate();
            _contacts.Add(model.Id, model);
            return model.Id;
        }

        public void Update(Contact model)
        {
            var createdDate = _contacts[model.Id].Created;
            model.Created = createdDate;
            _contacts[model.Id] = model;
        }

        public void Delete(int id)
        {
            _contacts.Remove(id);
        }

        public Contact? FindById(int id)
        {
            return _contacts[id];
        }

        public List<Contact> FindAll()
        {
            return _contacts.Values.ToList();
        }
    }
}
