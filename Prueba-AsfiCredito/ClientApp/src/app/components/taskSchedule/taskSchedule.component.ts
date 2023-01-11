import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';
import { TaskSchedule } from '../../services/taskSchedule/taskSchedule.service';

@Component({
  selector: 'app-task',
  templateUrl: './taskSchedule.component.html',
  styleUrls: ['./taskSchedule.component.css']
})
export class taskScheduleComponent {

  tareas: any;
  areas: any;
  activities: any;
  dateTask: any;

  formInsertarTask = new FormGroup({
    idArea: new FormControl(''),
    idActivity: new FormControl(''),
    dateTask: new FormControl(''),
    description: new FormControl('')
  })

  constructor(
    private TaskSchedule: TaskSchedule,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.cargarTareas();
    this.cargarAreas();
    this.cargarActivities();
  }

  cargarTareas() {
    this.TaskSchedule.getAllTasks().subscribe(res => {
      const resp = res as any;
      this.tareas = resp;
      console.log("tareas",this.tareas);
    });
  }

  cargarAreas() {
    this.TaskSchedule.getAllArea().subscribe(res => {
      const resp = res as any;
      this.areas = resp;
      console.log(this.areas);
    });
  }

  cargarActivities() {
    this.TaskSchedule.getAllActivity().subscribe(res => {
      const resp = res as any;
      this.activities = resp;
      console.log(this.activities);
    });
  }

  insertTask() {
    console.log("insert tasks", this.activities)
    const array = ({
      idClient: this.activities[0].id,
      hour: (<HTMLInputElement>document.getElementById("time")).value,
      state : 1
    })
    console.log("array", array)
    this.TaskSchedule.InsertTask(array).subscribe(res => {
      
      const resp = res as any;
      console.log(resp);
    }, err => {
      console.log("err", err)
      alert("*** ERROR *** \n The email or password or username is empty ");
    })
  }

}
