<template>
  <div class="keep col-sm-10 col-lg-3 m-auto">
    <!--NOTE Keep Card -->
    <div class="card promoting-card p-1 m-2" style="box-shadow: 1px 1px 10px #f57a007a">
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
        </div>
      </div>

      <!-- Keep image -->
      <div class="view overlay">
        <img class="card-img-top img-fluid" :src="keepData.img" />
      </div>

      <div class="card-body">
        <!-- Keep Description -->
        <h5>{{keepData.description}}</h5>
      </div>

      <!-- Keep Buttons -->
      <div class="card-footer text-center mb-1 mx-auto rounded shadow-sm border-0 bg-light">
        <!-- TODO View Keep -->
        <i
          class="fab fa-kaggle text-info btn border-bottom"
          @click="addKeepToVault()"
          data-toggle="tooltip"
          data-placement="top"
          title="Save to Vault"
        >
          :
          <span class="text-danger">{{keepData.keeps}}</span>
        </i>
        <!-- TODO Save Keep to Vault -->
        <i
          class="far fa-eye text-info btn border-bottom"
          @click="viewKeep()"
          data-toggle="tooltip"
          data-placement="top"
          title="I like it"
        >
          :
          <span class="text-danger">{{keepData.views}}</span>
        </i>
        <!-- TODO Keep Shares (not implemented) -->
        <i
          class="fas fa-share-square text-info btn disabled border-bottom"
          data-toggle="tooltip"
          data-placement="top"
          title="Share this Keep"
        >
          :
          <span class="text-danger">{{keepData.views}}</span>
        </i>

         <!-- IsPrivate icons  -->
          <a
            class="fas fa-lock-open text-danger"
            data-toggle="tooltip"
            data-placement="top"
            title="Toggle private status"
            v-show="keepData.isPrivate == false"
          >Public</a>
          <a
            class="fas fa-lock text-info"
            data-toggle="tooltip"
            data-placement="top"
            title="Toggle private status"
            v-show="keepData.isPrivate == true"
          >Private</a>
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
    }
  },
  components: {}
};
</script>


<style scoped>
</style>