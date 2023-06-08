//document.addEventListener('DOMContentLoaded', get, false);
//showStudent();
//function showStudent() {
//    var xhr = new XMLHttpRequest();
//    xhr.open('GET', 'School/LoadStudentList', true);
//    xhr.setRequestHeader("Content-Type", "application/json");
//    xhr.onload = function () {
//        if (this.status === 200) {
//            var studentList = JSON.parse(this.responseText);
//            loadData(studentList);
//        }
//        else alert("Error while loading Data");
//    };
//    xhr.send();
//}

$(document).ready(function () {
    $('#dataTable').DataTable();
});


//function loadData(list) {
//    for (let i = 0; i < list.length; i++) {
//        tr = '<tr class="odd">' +
//            '<td class="dtr-control sorting_1" tabindex="0">' + list[i].rollNumber + '</td>' +
//            '<td>' + list[i].firstName + ' ' + list[i].lastName + '</td>' +
//            '<td>' + list[i].fatherName + '</td>' +
//            '<td>' + list[i].phoneNumber+'</td>' +
//            '<td>' +
//            '<img src="~/Photo/' + list[i].studentPhoto + '" alt="Photo" width="120" height="120"/>' +
//                '</td>' +
//                '<td>' + list[i].classId + '</td>' +
//                '<td><a href="" class="btn btn-primary">Edit</a><a href="" class="btn btn-info">Details</a></td>' +
//                '</tr>';
//        document.getElementById('StudentList').innerHTML += tr;
//    }
//}