using Azure.Core;
using Business.Abstract;
using Business.Constanst;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MeetingRequestManager : IMeetingRequestService
    {
        IMeetingRequestDal _meetingRequestDal;
        IUserService _userService;
        public MeetingRequestManager(IMeetingRequestDal meetingRequestDal, IUserService userService)
        {
            _meetingRequestDal = meetingRequestDal;

            _userService = userService;
        }

        public IDataResult<List<MeetingRequest>> GetById(int id)
        {
            return new SuccessDataResult<List<MeetingRequest>>(_meetingRequestDal.GetAll(p => p.MeetingRequestId == id));
        }


        public IResult Update(MeetingRequest meetingRequest)
        {
            _meetingRequestDal.Update(meetingRequest);
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var meetingRequest = _meetingRequestDal.Get(m => m.MeetingRequestId == id);
            if (meetingRequest == null)
            {
                return new ErrorResult("Toplantı isteği bulunamadı");
            }

            _meetingRequestDal.Delete(meetingRequest);
            return new SuccessResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="meetingRequest"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public IResult ShowMeetingRequest(MeetingRequest meetingRequest,User user)
        {
            var claimUser = _userService.GetClaims(user);
            if (claimUser.Any(c => c.Name == "admin"))
            {
                return new SuccessDataResult<List<MeetingRequest>>(_meetingRequestDal.GetAll());
            }
        
                return new SuccessDataResult<List<MeetingRequest>>(_meetingRequestDal.GetAll(p=>p.InsertUserId==user.UserId));
            
        }

        public IDataResult<List<MeetingRequest>> GetReservedMeetingRequests()
        {
            DateTime currentDate = DateTime.Now.Date;
            TimeSpan currentTime = DateTime.Now.TimeOfDay;

            // Şuanki tarih ve saat aralığı içeren talepleri getir
            TimeSpan startTime = TimeSpan.FromTicks(currentTime.Ticks); // Zaman aralığı düzenlemesi
            TimeSpan endTime = TimeSpan.FromTicks(currentTime.Ticks + TimeSpan.TicksPerSecond); // Zaman aralığı düzenlemesi

            return new SuccessDataResult<List<MeetingRequest>>(_meetingRequestDal.GetAll(
                m => m.MeetingDate == currentDate &&
                TimeSpan.Parse(m.StartTime) <= startTime &&
                TimeSpan.Parse(m.EndTime) > endTime));
        }


        public IResult CreateMeetingRequest(MeetingRequest meetingRequest)
        {
            // 1. Uygunluk kontrolünü yap
            TimeSpan startTime = TimeSpan.Parse(meetingRequest.StartTime);
            TimeSpan endTime = TimeSpan.Parse(meetingRequest.EndTime);

            if (!IsMeetingTimeAvailable(meetingRequest.MeetingDate, startTime, endTime))
            {
                return new ErrorResult("Seçilen saat aralığı dolu.");
            }

            // 2. Diğer işlemleri gerçekleştir (örneğin ekleme işlemi)
            _meetingRequestDal.Add(meetingRequest);
            return new SuccessResult("Toplantı talebi oluşturuldu.");
        }


        private bool IsMeetingTimeAvailable(DateTime meetingDate, TimeSpan startTime, TimeSpan endTime)
        {
            TimeSpan availableStartTime = new TimeSpan(9, 0, 0);
            TimeSpan availableEndTime = new TimeSpan(18, 0, 0);

            if (startTime >= availableStartTime && endTime <= availableEndTime)
            {
                var conflictingMeetings = _meetingRequestDal.GetAll(
                    m => m.MeetingDate == meetingDate &&
                    ((TimeSpan.Parse(m.StartTime) <= startTime && TimeSpan.Parse(m.EndTime) > startTime) ||
                    (TimeSpan.Parse(m.StartTime) < endTime && TimeSpan.Parse(m.EndTime) >= endTime)));

                return conflictingMeetings.Count == 0;
            }

            return false;
        }
    }

}

    
    

    


