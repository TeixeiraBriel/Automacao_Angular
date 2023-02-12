import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlbionComponent } from './albion.component';

describe('AlbionComponent', () => {
  let component: AlbionComponent;
  let fixture: ComponentFixture<AlbionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AlbionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AlbionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
