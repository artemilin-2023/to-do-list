import RequsetResult from "./DTOs/RequsetResult";

export default class BoardApi {
  constructor(axiosInstance) {
    this.api = axiosInstance;
  }

  getAll(search, tags, dateRange, boardType) {
    let result;
    this.api
      .get("/boards/", {
        params: {
          search: search,
          tags: tags,
          dateFrom: dateRange[0],
          dateTo: dateRange[1],
          boardType: boardType,
        },
      })
      .then((response) => {
        result = new RequsetResult(
          response.status,
          response.data.message,
          response.data
        );
      })
      .catch((error) => {
        console.log(error);
      });
    return result;
  }

  async get(id) {
    return await this.api.get(`/boards/${id}`);
  }

  async delete(id) {
    console.log(`delete board: /boards/${id}`);
  }

  post(title, description, tags, teammates) {
    return;
  }

  patch(id, title, description, tags, teammates) {
    return;
  }
}
