import { Board } from "./DTOs/Board";
import RequsetResult from "./DTOs/RequsetResult";

export default class BoardApi {
  constructor(axiosInstance) {
    this.api = axiosInstance;
  }

  async getAll(search, tags, dateRange, boardType) {
    let result;
    await this.api
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
        let data = [];
        for (let i = 0; i < response.data.count; i++) {
          let item = response.data.data[i];
          data.push(
            new Board(
              item.id,
              item.title,
              item.description,
              item.createdAt,
              item.tags
            )
          );
        }
        result = new RequsetResult(response.status, data);
      })
      .catch((error) => {
        result = new RequsetResult(
          error.response.status,
          error.response.data,
          error.response.data.errorMessage
        );
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
