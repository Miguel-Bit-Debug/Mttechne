export class Payment {
  public desciption: string;
  public paymentDate: Date;
  public paymentType: number;
  public paymentAmount: number;

  constructor(desciption: string, paymentDate: Date,  paymentType: number, paymentAmount: number) {
    this.desciption = desciption;
    this.paymentDate = paymentDate;
    this.paymentType = paymentType;
    this.paymentAmount = paymentAmount;
  }
}
