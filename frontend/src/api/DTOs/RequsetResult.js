export default class RequsetResult {
  constructor(statusCode, responseData, errorMessage = null) {
    this._isSuccess = this.in200Range(statusCode);
    this._responseData = responseData;
    this._errorMessage = errorMessage;
  }

  get isSuccess() {
    return this._isSuccess;
  }

  get message() {
    return this._message;
  }

  get data() {
    return this._responseData;
  }

  get errorMessage() {
    return this._errorMessage;
  }

  in200Range(statusCode) {
    return (200 <= statusCode && statusCode <= 208) || statusCode == 226;
  }
}
