using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entity;

namespace Business.Abstract
{
    public interface IMeetingRequestService
    {
        IDataResult<List<MeetingRequest>> GetById(int id);
       
        IResult Update(MeetingRequest meetingRequest);
        IResult Delete(int id);
        IDataResult<List<MeetingRequest>> GetReservedMeetingRequests();
        IResult ShowMeetingRequest(MeetingRequest meetingRequest, User user);
        IResult CreateMeetingRequest(MeetingRequest meetingRequest);
  

        // Özel işlemler veya servis metotları burada tanımlanabilir
    }
}










