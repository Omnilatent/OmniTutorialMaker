# OmniTutorialMaker
This asset simplify the process of making tutorial.

# Tiếng Việt:

## Giới thiệu
Các tính năng có sẵn bao gồm:
- Lưu tiến trình Tutorial của người chơi.
- Hiển thị text hướng dẫn cho người chơi.
- Scriptable Tutorial Data giúp reference và quản lý các Tutorial trong game chắc chắn.

## Các bước Setup:
B1: Tạo object hiển thị text hướng dẫn. Bạn có thể dùng TextDisplay đi kèm sẵn trong thư viện hoặc tự viết script sử dụng interface ITutorialDisplay.

B2: Tạo gameObject có component Tutorial Step.

B3: Tạo Tutorial Data:
Bạn có thể tạo Tutorial Data bằng 1 trong 2 cách:
- Cách 1: Tạo trực tiếp trong TutorialStep: gán giá trị cho các trường trong Data ở Inspector.
- Cách 2: Tạo ScriptableTutorialData trong Assets bằng cách phải chuột vào cửa sổ Project, chọn Omnilatent > TutorialMaker Data.

B4: Khởi tạo giá trị data. Gán object display vừa tạo ở bước 1 vào trường displayObject.

## Sử dụng:
Nếu bạn check vào ô checkOnStart ở TutorialStep thì TutorialStep sẽ tự động kiểm tra xem Tutorial có thể hiển thị không và hiển thị Tutorial.

Nếu bạn muốn tự gọi code thì bỏ check ô checkOnStart và gọi hàm TutorialStep.Init().

## Ví dụ
Bạn có thể xem ví dụ trong thư mục Example.
