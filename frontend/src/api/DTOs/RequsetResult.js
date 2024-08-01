export default class RequsetResult {
  constructor(statusCode, message, responseData) {
    this._isSuccess = this.in200Range(statusCode);
    this._message = message;
    this._responseData = responseData;
  }

  get isSuccess() {
    return this._isSuccess;
  }

  get message() {
    return this._message;
  }

  get responseData() {
    return this._responseData;
  }

  in200Range(statusCode) {
    return (200 <= statusCode && statusCode <= 208) || statusCode == 226;
  }
}
