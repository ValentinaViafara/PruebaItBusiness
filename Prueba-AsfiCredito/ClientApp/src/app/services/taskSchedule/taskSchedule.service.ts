import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TaskSchedule {

  constructor(private http: HttpClient) { }

  public url = window.location.hostname;
  public port = window.location.port;

  public getAllTasks() {
    return this.http.get('https://' + this.url + ":" + this.port + "/api/taskSchedule");
  }
  public InsertTask(array: any) {
    // return this.http.post('https://' + this.url + ":" + this.port + "/api/taskSchedule", {task: array, dateTask: dateTask});
    return this.http.post('https://' + this.url + ":" + this.port + "/api/taskSchedule", array);
  }

  public UpdateClient(array: any, id: string) {
    return this.http.put('https://' + this.url + ":" + this.port + "/api/taskSchedule/" + id, array);
  }

  public getAllArea() {
    console.log('https://' + this.url + ":" + this.port + "/api/taskSchedule")
    return this.http.get('https://' + this.url + ":" + this.port + "/api/taskSchedule/area");
  }
  public getAllActivity() {
    console.log('https://' + this.url + ":" + this.port + "/api/taskSchedule")
    return this.http.get('https://' + this.url + ":" + this.port + "/api/taskSchedule/activities");
  }

}
