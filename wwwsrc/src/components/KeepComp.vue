<template>
  <div class="keep">
    <div class="col-sm-12 my-3">
      <!--NOTE Keep Card -->
      <div class="card promoting-card p-1" style="box-shadow: 1px 1px 10px #f57a007a">

        <!-- dropdown toggle options -->
    <div class="dropdown show" v-if="$auth.user.sub == keepData.userId">
            <button
              class="bg-transparent border-0"
              href="#"
              role="button"
              id="dropdownMenuLink"
              data-toggle="dropdown"
              aria-haspopup="true"
              aria-expanded="false"
            >
              <i class="fas fa-ellipsis-h"></i>
            </button>
            <div class="dropdown-menu" aria-labelledby="dropdownMenuLink">
              <button
                class="btn text-danger btn-sm ml-4"
                style="font-size: 1.1rem"
                @click="deleteKeep()"
                data-toggle="tooltip"
                data-placement="top"
                title="Delete This Keep"
              >Delete Keep</button>
            </div>
          </div>

        <!-- Card content -->
        <div class="card-body d-flex flex-row">
          <!-- TODO User Image -->
          <img
            src="https://mdbootstrap.com/img/Photos/Avatars/avatar-8.jpg"
            class="rounded-circle mr-3"
            height="50px"
            width="50px"
            alt="avatar"
          />

          <!-- Content -->
          <div>
            <!-- Title -->
            <h4 class="card-title font-weight-bold mb-2">{{keepData.name}}</h4>
            <!--TODO Created at Date -->
            <p class="card-text">
              <i class="far fa-clock pr-2"></i>createdAt: not implemented
            </p>
            <!-- TODO IsPrivate  -->
            <a
              class="fas fa-lock-open green-text"
              data-toggle="tooltip"
              data-placement="top"
              title="Toggle private status"
              v-show="keepData.isPrivate == false"
            ></a>
            <a
              class="fas fa-lock red-text"
              data-toggle="tooltip"
              data-placement="top"
              title="Toggle private status"
              v-show="keepData.isPrivate == true"
            ></a>
          </div>
        </div>

        <!-- Keep image -->
        <div class="view overlay">
          <img class="card-img-top rounded-0 img-fluid" :src="keepData.img" />
          <a href="#!">
            <div class="mask rgba-white-slight"></div>
          </a>
        </div>

        <div class="card-body">
          <!-- Keep Description -->
          <h5>{{keepData.description}}</h5>

          <!-- Buttons -->
          <!-- Read More Description Button -->
          <a
            class="btn btn-flat red-text p-1 my-1 mr-0 mml-1 collapsed"
            data-toggle="collapse"
            href="#collapseContent"
            aria-expanded="false"
            aria-controls="collapseContent"
          ></a>
          <!-- TODO Share Keep -->
          <i
            class="fas fa-share-alt text-muted float-right p-1 my-1"
            data-toggle="tooltip"
            data-placement="top"
            title="Share this post"
          ></i>
          <!-- TODO Save Keep to Vault -->
          <i
            class="fas fa-heart text-muted float-right p-1 my-1 mr-3"
            data-toggle="tooltip"
            data-placement="top"
            title="I like it"
          ></i>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "keep",
  props: ["keepData"],
  data() {
    return {};
  },
  computed: {},
  methods: {
    deleteKeep() {
      Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
      }).then(result => {
        if (result.value) {
          Swal.fire("Deleted!", "Your Keep has been deleted.", "success");
          this.$store.dispatch("deleteKeep", this.keepData.id);
        }
      });
    },
  },
  components: {}
};
</script>


<style scoped>
</style>