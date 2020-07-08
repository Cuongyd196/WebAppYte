Chủ đề 2 : Hỗ trợ y tế từ xa

Sinh viên thực hiện : Nguyễn Văn Cường
Lớp: K20B
Mã SV: 1661030063
Ngôn ngữ : Asp.net mvc, sql server.

Video demo: https://youtu.be/3z0H2xfT_ck


- Mô tả hoạt động website

- Người dùng là khách ( chưa đăng nhập ) : 
+ Có thể xem số liệu covid, tin tức covid về cách phòng tránh, tin mới
tin tức được cập nhật hàng ngày bởi quản trị viên.
+ Xem các câu hỏi và câu trả lời của những người dùng đã hỏi và bác sĩ đã trả lời.
Muốn gửi câu hỏi mới phải đăng nhập tài khoản.
+ Xem trung tâm y tế gần nhất : chọn tỉnh thành cần tra cứu. Bấm tra cứu- hiển thị danh sách
trung tâm, bệnh viện. Bấm xem chi tiết sẽ hiển thị chi tiết.

- Người dùng đã đăng nhập : (tk: Benhnhan: mk 123456)
+ Xem hồ sơ, cập nhật hồ sơ, xem lịch sử tư vấn.
+ Có thể gửi câu hỏi mới, trò chuyện với bác sĩ, xem câu hỏi.
+ Xem danh sách bác sĩ, thông tin bác sĩ.
+ Đặt lịch tư vấn quá video:  Đặt lịch nhập nội dung, chọn bác sĩ, chọn thời gian bắt đầu.
Bấm gửi - Lịch hẹn ở trạng thái chờ xác nhận. 
 * Khi đã được xác nhận - Trạng thái đã xác nhận được bật:
Sẽ hiển thị đếm ngược thời gian cho người dùng. Khi đến thời gian tư vấn sẽ xuất hiện link zoom của bác sĩ.
Nhấp vào link zoom để vào trò chuyện với bác sĩ.
Khi tư vấn xong, sẽ có trạng thái đã tư vấn xong. Bác sĩ sẽ có kết luận, giải đáp về cuộc trò chuyện.
Tối đa 40 phút 1 cuộc tư vấn.Khi tư vấn kết thúc sớm bác sĩ nhập thời gian kết thúc tư vấn


- Bác sĩ : (tk: Bacsy: mk 123456)
+ Được cấp tài khoản bởi người quản trị:
Đăng nhập thành công sẽ có danh mục : Trả lời câu hỏi và Danh sách lịch hẹn.
+ Trả lời giải đáp của người dùng
+ Xác nhận lịch hẹn, có thể bấm đổi lịch hẹn/ từ chối lịch hẹn nhập nội dung để thông báo tới người dùng.
+ Khi tư vấn xong sẽ nhập thời gian kết thúc cuộc trò chuyện và trả cho người dùng ghi chú về cuộc nói chuyện.
+ Xử lí khi có nhiều lịch trùng : Sẽ từ chối, đổi lịch cho bệnh nhân khung giờ khác và thông báo đến cho bệnh nhân.
+ Khi sắp đến giờ tư vấn sẽ có nhân viên trung tâm lên lạc số điện thoại và email của người dùng để thông báo lịch hẹn.


- Người quản trị : (tk: admin: mk 123456)
+ Quản lý chung hệ thống.
+ Cập nhật tin tức, số liệu. Thêm mới bác sĩ, trung tâm y tế.

-KHÁC: WEB hỗ trợ tương thích với nhiều màn hình thiết bị. 
